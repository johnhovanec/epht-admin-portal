using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml; // Install EPPlus for this
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using epht_admin_portal.Models; // Your DbContext namespace

public class UploadExcelModel : PageModel
{
    private readonly MdhephtContext _context;

    public UploadExcelModel(MdhephtContext context)
    {
        _context = context;
    }

    [BindProperty]
    public IFormFile Upload { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Upload == null || Upload.Length == 0)
        {
            return RedirectToPage("Error", new { errorMessage = "Please upload a valid Excel file." });
        }

        // Check file type
        if (!Upload.ContentType.Equals("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", StringComparison.OrdinalIgnoreCase))
        {
            return RedirectToPage("Error", new { errorMessage = "Only Excel files (.xlsx) are allowed" });
        }

        try
        {
            using (var stream = new MemoryStream())
            {
                await Upload.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    // Check if the worksheet exists
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == "asthma_crude_ED_state");
                    if (worksheet == null)
                    {
                        return RedirectToPage("Error", new { errorMessage = "The required worksheet 'asthma_crude_ED_state' is missing." });
                    }

                    int rowCount = worksheet.Dimension?.Rows ?? 0;

                    for (int row = 2; row <= rowCount; row++) // Assuming row 1 = headers
                    {
                        try
                        {
                            var entity = new AsthmaNcdmStatewideSSISTest
                            {
                                TypeId = 17, // Replace with dynamic logic if needed
                                Mdcode = "000",
                                Year = worksheet.Cells[row, 2].GetValue<int>(),
                                Rate = worksheet.Cells[row, 3].GetValue<decimal>(),
                                GroupAgeId = 77,
                                GenderCode = "77",
                                RaceCode = "77",
                            };

                            if (entity.Rate > 0) // Filter out empty rows
                            {
                                _context.AsthmaNcdmStatewideSSISTests.Add(entity);
                            }
                            else
                            {
                                return RedirectToPage("Error", new { errorMessage = $"Invalid data detected: Worksheet name: {worksheet.Name}, row number: {row}, has an invalid negative rate value of {entity.Rate}. Please correct and retry." });
                            }
                        }
                        catch (Exception ex)
                        {
                            return RedirectToPage("Error", new { errorMessage = $"Error processing row {row}: {ex.Message}" });
                        }
                    }

                    await _context.SaveChangesAsync();
                }
            }
        }
        catch (Exception ex)
        {
            return RedirectToPage("Error", new { errorMessage = $"An error occurred while processing the file: {ex.Message}" });
        }

        return RedirectToPage("Success");
    }
}
