﻿using BookShopping.Model.Models;
using BookShopping.Service.Data;
using BookShopping.Service.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopping.Service.Repository
{
    public class CategoyRepository: Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
