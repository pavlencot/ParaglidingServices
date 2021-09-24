using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;

        public BaseController()
        {

        }

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
