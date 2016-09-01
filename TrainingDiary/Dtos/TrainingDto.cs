using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Entities;

namespace TrainingDiary.Dtos
{
    //public class TrainingType
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    public string Name { get; set; }

    //    public virtual ICollection<Entities.Training> Trainings { get; set; }
    //}

    //public enum Intensity
    //{
    //    Low,
    //    Medium,
    //    High
    //}

    public class TrainingDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string TrainingTypeName { get; set; }
    }

    public class TrainingMetadataDto
    {
        public int Id { get; set; }

        public double Distance { get; set; }
        public TimeSpan Time { get; set; }
        public Intensity Intensity { get; set; }

        public double AverageSpeed { get; set; }
        public double AverageTempo { get; set; }
        public double AverageHeartRate { get; set; }
    }

    //public class TrainingMapper
    //{
    //    public void Map()
    //    {
    //        Mapper.Initialize(m=> m.CreateMap<Training, TrainingDto>().ForMember(x=>x.TrainingTypeName, opt=>opt.MapFrom(y=>y.Type.Name)));
    //        Mapper.Initialize(m => m.CreateMap<TrainingMetadata, TrainingMetadataDto>());
    //    }
    //}
}