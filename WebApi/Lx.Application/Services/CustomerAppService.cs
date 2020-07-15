using Lx.Application.Interfaces;
using Lx.Application.ViewModels;
using Lx.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerAppService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public IEnumerable<CustomerViewModel> GetAll()
        {
            return null;
            //return _customerRepository.GetAll().ProjectTo<CustomerViewModel>();
        }

        public CustomerViewModel GetById(Guid id)
        {
            return null;
        }

        public void Register(CustomerViewModel customerViewModel)
        {

        }

        public void Update(CustomerViewModel customerViewModel)
        {

        }

        public void Delete(Guid id)
        {

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
