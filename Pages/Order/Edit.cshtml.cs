using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderModel = ASPCRUD.Models.Order;

namespace ASPCRUD.Pages.Order;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public OrderModel Order { get; set; } = null!;

    public void OnGet(int id)
    {
        Order = _context.Orders.Find(id)!;
    }

    public IActionResult OnPost()
    {


        _context.Orders.Update(Order);
        _context.SaveChanges();
        // Redirect to Page
        return RedirectToPage("Index");
    }

}