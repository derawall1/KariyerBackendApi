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
    public class JobsController : ControllerBase
    {
        private readonly IEmployerRepo _employerRepository;
        private readonly IJobRepo _jobRepository;
        private readonly IMapper _mapper;

        public JobsController(IEmployerRepo employerRepository, IJobRepo jobRepository, IMapper mapper)
        {
            _employerRepository = employerRepository;
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobRepository.GetAllJobs();

            if (jobs != null)
            {
                return Ok(_mapper.Map<IEnumerable<RetrieveJobDto>>(jobs));
            }

            return NotFound();
        }

        [HttpGet]
        [Route("employers/{employerId}/jobs")]
        public async Task<IActionResult> GetAllJobsByEmployerId(int employerId)
        {
            var jobs = await _jobRepository.GetAllJobsByEmployerId(employerId);

            if (jobs != null)
            {
                return Ok(_mapper.Map<IEnumerable<RetrieveJobDto>>(jobs));
            }

            return NotFound();
        }
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearcgJobs([FromQuery] string? searchTerm = "", [FromQuery] DateTime? dateFrom = null, [FromQuery] DateTime? dateTo = null)
        {
            var jobs = await _jobRepository.SearchJobs(searchTerm,dateFrom, dateTo);

            if (jobs != null)
            {
                return Ok(_mapper.Map<IEnumerable<RetrieveJobDto>>(jobs));
            }

            return NotFound();
        }
        [HttpGet]
        [Route("{id}/get")]
        public async Task<IActionResult> GetJobById(int id)
        {

            var job = await _jobRepository.GetJobById(id);

            if (job != null)
            {
                return Ok(_mapper.Map<RetrieveJobDto>(job));
            }

            return NotFound();
        }

        [HttpPost]
        [Route("employers/{employerId}/create")]
        public async Task<IActionResult> CreateJob(int employerId, CreateJobDto job)
        {
            var response = new ResponseDto();
           
            var employer = await _employerRepository.GetEmployerById(employerId);
           
           
            if (employer == null)
            {
                response.Message = "";
                response.Error = "Employer with given id is not present in system!";

                return BadRequest(response);
            }

            if(employer.NumberOfJobAdsToPost <=0)
            {
                response.Message = "";
                response.Error = "You don't have enough limit to post the job!";

                return BadRequest(response);
            }

            var objJob = _mapper.Map<Job>(job);
            objJob.Employer = employer;
            await _jobRepository.CreateJob(objJob);
            employer.NumberOfJobAdsToPost = employer.NumberOfJobAdsToPost - 1;
            await _employerRepository.UpdateEmployer(employer.Id, employer);

            response.Message = "Job created sucessfully!";
            response.Error = "";

            return Ok(response);
        }

        [HttpPut]
        [Route("employers/{employerId}/{id}/update")]
        public async Task<IActionResult> UpdateJob(int employerId, int id, UpdateJobDto job)
        {
            var response = new ResponseDto();

            var employer = await _employerRepository.GetEmployerById(employerId);


            if (employer == null)
            {
                response.Message = "";
                response.Error = "Employer with given id is not present in system!";

                return BadRequest(response);
            }
            var objJob = _mapper.Map<Job>(job);
            objJob.Employer = employer;
            objJob.Id = id;
            await _jobRepository.UpdateJob(id, objJob);

            response.Message = "Job updated sucessfully!";
            response.Error = "";

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            await _jobRepository.DeletedJob(id);

            return Ok();
        }
    }
}
