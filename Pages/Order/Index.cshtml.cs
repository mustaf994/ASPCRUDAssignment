using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderModel = ASPCRUD.Models.Order;

namespace ASPCRUD.Pages.Order;

public class IndexModel : PageModel
{
    // connect database 
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    // property

    public List<OrderModel> Orders { get; set; } = new();

    public void OnGet()
    {
        Orders = _context.Orders.ToList();
    }

}