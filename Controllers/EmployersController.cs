using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KariyerBackendApi.Data;
using KariyerBackendApi.Models;
using AutoMapper;
using KariyerBackendApi.Dtos;

namespace KariyerBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployersController : ControllerBase
    {
        private readonly IEmployerRepo _repository;
        private readonly IMapper _mapper;

        public EmployersController(IEmployerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllEmployers()
        {
            var employers = await _repository.GetAllEmployers();

            if (employers != null)
            {
                return Ok(_mapper.Map<IEnumerable<RetrieveEmployerDto>>(employers));
            }

            return NotFound();
        }

        [HttpGet]
        [Route("{id}/get")]
        public async Task<IActionResult> GetEmployersById(int id)
        {

            var employer = await _repository.GetEmployerById(id);

            if (employer != null)
            {
                return Ok(_mapper.Map<RetrieveEmployerDto>(employer));
            }

            return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateEmployer(CreateEmployerDto employer)
        {
            var response = new ResponseDto();
            var isExites = await _repository.IsExits(employer.PhoneNumber, null);
            if(isExites)
            {
                response.Message = "";
                response.Error = "phone number already exists with another employer!";

                return BadRequest(response);
            }
            var emp = _mapper.Map<Employer>(employer);
            await _repository.CreateEmployer(emp);

            response.Message = "Employer created sucessfully!";
            response.Error = "";

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}/update")]
        public async Task<IActionResult> UpdateEmployer(int id, UpdateEmployerDto employer)
        {
            var response = new ResponseDto();
            var isExites = await _repository.IsExits(employer.PhoneNumber, id);
            if (isExites)
            {
                response.Message = "";
                response.Error = "phone number already exists with another employer!";

                return BadRequest(response);
            }
            var emp = _mapper.Map<Employer>(employer);
            await _repository.UpdateEmployer(id, emp);

            response.Message = "Employer created sucessfully!";
            response.Error = "";

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<IActionResult> DeleteEmployer(int id)
        {
            await _repository.DeletedEmployer(id);

            return Ok();
        }
    }
}
