﻿using GestionEtudiants.Context;
using GestionEtudiants.Interfaces;
using GestionEtudiants.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GestionEtudiants.Application
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext dbContext;
        public StudentRepository(AppDbContext context) {
            dbContext = context;
        }
        public Student Add(Student student)
        {
            var st = dbContext.Students.Add(student);
            dbContext.SaveChanges();
            return student;
        }

        public int Delete(int StudentId)
        {
            Student student = dbContext.Students.Find(StudentId);
            dbContext.Students.Remove(student);
           return dbContext.SaveChanges();
        }

        public List<Student> GetAll()
        {
            var students = dbContext.Students.ToList();
            //return DataSource();
            return students;
        }

        public Student GetStudentById(int StudentId)
        {
            //return DataSource().FirstOrDefault(prop => prop.StudentId == StudentId);
            var student = dbContext.Students
                .SingleOrDefault(s => s.StudentId == StudentId);
            return student;
        }

        public Student Update(Student student)
        {
            var st = dbContext.Students.Update(student);
            dbContext.SaveChanges();

            return student;
        }
    }
}
