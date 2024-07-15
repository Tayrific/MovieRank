﻿using MovieRank.Libs.Models;
using MovieRank.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRank.Libs.Mappers
{
    public class Mapper : IMapper
    {
        public IEnumerable<MovieResponse> ToMovieContract(IEnumerable<MovieDb> items)
        {
            return items.Select(ToMovieContract);
        }

        public MovieResponse ToMovieContract(MovieDb movie)
        {
            return new MovieResponse
            {

                MovieName = movie.MovieName,
                Description = movie.Description,
                Actors = movie.Actors,
                Ranking = movie.Ranking,
                RankedDateTime = movie.RankedDateTime,
            };
        }

        public MovieDb ToMovieDbModel(int userId, MovieRankRequest movieRankRequest)
        {
            return new MovieDb
            {
                UserId = userId,
                MovieName = movieRankRequest.MovieName,
                Description = movieRankRequest.Description,
                Actors = movieRankRequest.Actors,
                Ranking = movieRankRequest.Ranking,
                RankedDateTime = DateTime.UtcNow.ToString()
            };
        }

        public MovieDb ToMovieDbModel(int userId, MovieDb movieDbRequest, MovieUpdateRequest movieUpdateRequest)
        {
            return new MovieDb
            {
                UserId = movieDbRequest.UserId,
                MovieName = movieDbRequest.MovieName,
                Description = movieDbRequest.Description,
                Actors = movieDbRequest.Actors,
                Ranking = movieUpdateRequest.Ranking,
                RankedDateTime = DateTime.UtcNow.ToString()
            };
        }

    }
}
