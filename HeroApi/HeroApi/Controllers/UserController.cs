using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace HeroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public UserController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
    }
}
