using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderModel = ASPCRUD.Models.Order;

namespace ASPCRUD.Pages.Order;

public class CreateModel : PageModel
{

    // Connect Database
    private readonly ApplicationDbContext _context; 
    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }
    // Binding Property 
    [BindProperty]
    public string CustomerName { get; set; } = string.Empty;
    [BindProperty]
    public string ProductName { get; set; } = string.Empty;
    [BindProperty]
    public int Quantity { get; set; }
    [BindProperty]
    public decimal Price { get; set; }
    [BindProperty]
    public DateTime? OrderDate { get; set; }
   
    public IActionResult OnPost()
    {


        var order = new OrderModel
        {
            CustomerName = CustomerName,
            ProductName = ProductName,
            Quantity = Quantity,
            Price = Price,
            OrderDate = OrderDate,

        }; 

        // Save Records
       
        _context.Orders.Add(order);
        _context.SaveChanges();
        // Redirect to Page
        return RedirectToPage("Index");
    }
    
}