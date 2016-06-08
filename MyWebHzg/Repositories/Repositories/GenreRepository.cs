using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebHzg.Entities;
using MyWebHzg.Repositories;
using MyWebHzg.BaseRepositories;

namespace MyWebHzg.Repositories
{

    public partial class GenreRepository : GenericRepository<Genre, MovieContext>, IGenreRepository
   {

   }

}