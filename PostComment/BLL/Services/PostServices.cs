using AutoMapper;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PostServices
    {
        public static List<PostDTO> Get()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<PostDTO, Post>();

            });
            var mapper = new Mapper(config);
            var rtdata = DataAccessFectory.PostDataAccess().Get();

            return mapper.Map<List<PostDTO>>(rtdata);
        }

        public static PostDTO Get(int Id)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<PostDTO, Post>();

            });
            var mapper = new Mapper(config);
            var rtdata = DataAccessFectory.PostDataAccess().Get(Id);

            return mapper.Map<PostDTO>(rtdata);
        }

        public static PostDTO Add(PostDTO data)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<PostDTO, Post>();

            });
            var mapper = new Mapper(config);
            var rtdata = DataAccessFectory.PostDataAccess().Add(mapper.Map<Post>(data));
            return mapper.Map<PostDTO>(rtdata);
        }
    }
}
