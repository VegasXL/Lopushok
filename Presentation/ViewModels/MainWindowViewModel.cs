using Microsoft.EntityFrameworkCore;
using Osipov.Lopushok.Domain.Entities;
using Osipov.Lopushok.Infrastructure.Persistence;
using Osipov.Lopushok.Persistence.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Osipov.Lopushok.Presentation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public List<Product> Products { get; private set; }

        public MainWindowViewModel()
        {

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Products = context.Products
                    .Include(pt => pt.ProductType)
                    .Include(p => p.ProductMaterials)
                    .ThenInclude(pm => pm.Material)
                    .ToList();
            }
        }
    }
}
