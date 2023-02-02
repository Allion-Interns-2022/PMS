using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PMSWebAPI.Controllers
{
    [Route("api/medicalrecords")]
    [ApiController]
    [Authorize]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public MedicalRecordsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<MedicalRecordsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var medicalRecordList = await _unitOfWork.MedicalRecordRepository.GetAll();
                return Ok(medicalRecordList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<MedicalRecordsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var existMedicalRecord = await _unitOfWork.MedicalRecordRepository.GetById(id);
                if (existMedicalRecord != null)
                {
                    return Ok(existMedicalRecord);
                }
                else
                {
                    return BadRequest("Medical Record is not available");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<MedicalRecordsController>/5
        [HttpGet("patient/{id}")]
        public async Task<IActionResult> GetRecordByPatientId(int id)
        {
            try
            {
                var existMedicalRecord = await _unitOfWork.MedicalRecordRepository.GetMedicalRecordByPatientId(id);
                if (existMedicalRecord != null)
                {
                    return Ok(existMedicalRecord);
                }
                else
                {
                    return BadRequest("No medical records available for selected patient.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<MedicalRecordsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MedicalRecord entity)
        {
            try
            {
                bool isAdded = await _unitOfWork.MedicalRecordRepository.AddEntity(entity);
                           await _unitOfWork.CompleteAsync();

                if (isAdded)
                {
                    return Ok("Medical Record is added.");
                }
                else
                {
                    return BadRequest("Something is wrong with input.");
                }   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MedicalRecordsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MedicalRecord entity)
        {
            try
            {
                var existMedicalRecord = await _unitOfWork.MedicalRecordRepository.GetById(id);

                if (existMedicalRecord != null)
                {
                    existMedicalRecord.SampleCollectedDate = entity.SampleCollectedDate;
                    existMedicalRecord.SugarMmol = entity.SugarMmol;
                    existMedicalRecord.TemperatureCelcius = entity.TemperatureCelcius;
                    existMedicalRecord.PlateletMmol = entity.PlateletMmol;
                    existMedicalRecord.HemoglobinGdl = entity.HemoglobinGdl;
                    existMedicalRecord.PatientId = entity.PatientId;

                    bool isEdited = await _unitOfWork.MedicalRecordRepository.UpdateEntity(existMedicalRecord);
                    await _unitOfWork.CompleteAsync();

                    if (isEdited)
                    {
                        return Ok("Medical Record is updated.");
                    }
                    else
                    {
                        return BadRequest("Something is wrong with input.");
                    }
                }
                else
                {
                    return BadRequest("Medical Record is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<MedicalRecordsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existMedicalRecord = await _unitOfWork.MedicalRecordRepository.GetById(id);
                if (existMedicalRecord != null)
                {
                    bool isDeleted = await _unitOfWork.MedicalRecordRepository.DeleteEntity(id);
                    await _unitOfWork.CompleteAsync();

                    if (isDeleted)
                    {
                        return Ok("Medical Record is deleted.");
                    }
                    else
                    {
                        return BadRequest("Something is wrong with input.");
                    }
                }
                else
                {
                    return BadRequest("Medical Record is not available.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
