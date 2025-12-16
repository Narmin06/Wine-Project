using App.Core.Entities.Payments;
using App.DAL.Presistence;
using App.DAL.Repositories.Abstractions;
using App.DAL.Repositories.Interfaces;

namespace App.DAL.Repositories.Implementations;

public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
{
	public InvoiceRepository(AppDbContext context) : base(context) { }
}
