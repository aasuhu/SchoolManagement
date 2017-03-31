using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Xml;
using System.Xml.Linq;

namespace School
{
    static class Helper
    {
        public static SchoolDataContext dc = new SchoolDataContext(Properties.Settings.Default.SchoolDBConnectionString);

        public static void AddStudent(Student s)
        {
            dc.Students.InsertOnSubmit(s);
            dc.SubmitChanges();
        }

        public static void UpdateStudent(Student s)
        {
            Student st = dc.Students.Where(ss => ss.StudentID == s.StudentID).SingleOrDefault();
            st.FirstName = s.FirstName;
            st.LastName = s.LastName;
            st.Gender = s.Gender;
            dc.SubmitChanges();
        }

        public static void DeleteStudent(Student s)
        {
            dc.Students.DeleteOnSubmit(s);
            dc.SubmitChanges();
        }

        public static void AddSubject(Subject sb)
        {
            dc.Subjects.InsertOnSubmit(sb);
            dc.SubmitChanges();
        }

        public static void UpdateSubject(Subject sb)
        {
            Subject s = dc.Subjects.Where(ss => ss.SubjectID == sb.SubjectID).SingleOrDefault();
            s.SubjectName = sb.SubjectName;
            s.SubjectDescription = sb.SubjectDescription;
            s.SubjectCredits = sb.SubjectCredits;
            dc.SubmitChanges();
        }
        public static void DeleteSubject(Subject sb)
        {
            dc.Subjects.DeleteOnSubmit(sb);
            dc.SubmitChanges();
        }

        internal static void addRegistration(Registration reg)
        {
            dc.Registrations.InsertOnSubmit(reg);
            dc.SubmitChanges();
        }

        public static void RegisterStudentInSubject(Registration reg)
        {
            dc.Registrations.InsertOnSubmit(reg);
            dc.SubmitChanges();
        }

        public static void RemoveStudentFromSubject(Registration reg)
        {
            dc.Registrations.DeleteOnSubmit(reg);
            dc.SubmitChanges();
        }

        #region LINQ To XML
        public static void SaveXML()
        {
            #region Saving Students XML
            XDocument StudentsDocument = new XDocument
                (
                    new XDeclaration("1.0", "UTF-8", "yes"),
                    new XElement("Students",
                            from s in dc.Students
                            select new XElement("Student", new XAttribute("ID", s.StudentID),
                                                            new XElement("FirstName", s.FirstName),
                                                            new XElement("LastName", s.LastName),
                                                            new XElement("Gender", s.Gender)
                         ))
                );

            StudentsDocument.Save("Students.xml");
            #endregion

            #region Saving Subjects XML
            XDocument SubjectsDocument = new XDocument
                (
                    new XElement("Subjects",
                               from sb in dc.Subjects
                               select new XElement
                                            (   "Subject", new XAttribute("ID", sb.SubjectID),
                                                new XElement("Name", sb.SubjectName),
                                                new XElement("Description", sb.SubjectDescription),
                                                new XElement("Credits", sb.SubjectCredits)
                                            )
                                )
                );
            SubjectsDocument.Save("Subjects.xml");

            #endregion

            #region Saving Registrations xml
            XDocument RegistrationsXML = new XDocument
                (
                    new XElement("Registration",
                        from r in dc.Registrations
                        select new XElement("Registration", new XAttribute("ID", r.RegistrationID),
                                            new XElement("StudentID",r.StudentID),
                                            new XElement("SubjectID", r.SubjectID),
                                            new XElement("Grade",r.Grade),
                                            new XElement("Status",r.Status)
                                            )
                                )
                );

            RegistrationsXML.Save("Registartions.xml");

            #endregion
        }

        public static dynamic LoadStudents()
        {
            var q = (from s in XDocument.Load("Students.xml").Descendants("Student")
                     select new { ID = s.Attribute("ID").Value,
                                    FirstName = s.Element("FirstName").Value,
                                    LastName=s.Element("LastName").Value,
                                    Gender= s.Element("Gender").Value
                     }
                    
                     ).ToList();

            return q;
        }
        #endregion

    }
}
