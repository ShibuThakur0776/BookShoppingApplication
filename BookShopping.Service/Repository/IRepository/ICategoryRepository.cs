using BookShopping.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopping.Service.Repository.IRepository
{
    public interface ICategoryRepository:IRepostory<Category>
    {
    }
}
//class Animal  -- fSour legs 
//  |
//  |
//sub class dog , cat ,horse inherit Animal
// dog --> Bark, four legs
// cat --> meow, four legs 
// horse --> run, four legs  