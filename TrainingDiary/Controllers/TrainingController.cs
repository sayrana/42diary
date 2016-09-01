using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using DAL;
using DAL.Repositories;
using Entities;
using TrainingDiary.Dtos;

namespace TrainingDiary.Controllers
{
    public class TrainingController : BaseController
    {
        private UnitOfWork unitOfWork { get; set; }
        private GenericRepository<Training> trainingRepository { get; set; }

        public TrainingController()
        {
            unitOfWork = new UnitOfWork(new DatabaseContext());
            trainingRepository = unitOfWork.Repository<Training>();
            trainingRepository.Add(new Training() {Name = "Midnight Jogging", Date = DateTime.Now.AddDays(-1), Type = new TrainingType() {Name = "Jogging"}});
            trainingRepository.Add(new Training() { Name = "Evening Jogging", Date = DateTime.Now });
            unitOfWork.Save();

            Mapper.Initialize(m => m.CreateMap<Training, TrainingDto>().ForMember(x => x.TrainingTypeName, opt => opt.MapFrom(y => y.Type.Name)));
            //Mapper.Initialize(m => m.CreateMap<TrainingMetadata, TrainingMetadataDto>());
        }

        public IEnumerable<TrainingDto> Get()
        {
            // return new string[] { "value1", "value2" };
            var trainings = trainingRepository.Get().ToList();
            var dto = new List<TrainingDto>();
            foreach (var training in trainings)
            {
                dto.Add(Mapper.Map<TrainingDto>(training));
            }
            return dto;
        }

        // GET api/values/5
        public User1 Get(int id)
        {
            //return "value";
            return new User1 { Id = 1, Name = "John Doe 111" };
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(User1 user)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
