using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;
using AutoMapper;
using DAL.Entity;
using BLL;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryBusiness _categoryBusiness;
        private readonly IMapper _mapper;

        public CategoryController(
            ICategoryBusiness categoryBusiness,
            IMapper mapper
            )
        {
            _categoryBusiness = categoryBusiness;
            _mapper = mapper;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HOST.Modals.Response.Category>>> GetCategories()
        {
            return Ok(_mapper.Map<List<HOST.Modals.Response.Category>>(await _categoryBusiness.GetCategories()));
        }
    }
}
