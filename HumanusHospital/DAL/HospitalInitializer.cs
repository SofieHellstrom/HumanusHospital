using HumanusHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanusHospital.DAL
{
    public class HospitalInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HospitalContext> //deletes db if any of the models classes change.
    {
        protected override void Seed(HospitalContext context) //creates seed data in db for testing purposes
        {
            var patients = new List<Patient>
            {
            new Patient{PersonIDNr="19880213-3478", FirstName="Kim", LastName="Guld", Address="Countryroad 20", Zipcode=12345, City="Kansas", Phone="0764-233445"},
            new Patient{PersonIDNr="19870523-5555", FirstName="Maria", LastName="Gustavsson", Address="Lyckostigen 13", Zipcode=12345, City="Kansas", Phone="0764-233445"},
            new Patient{PersonIDNr="19680901-7690", FirstName="Donald", LastName="Trump", Address="Engata", Zipcode=12345, City="Kansas", Phone="0764-233445"},
            new Patient{PersonIDNr="19440723-2213", FirstName="George", LastName="Curious", Address="Countryroad 20", Zipcode=12345, City="Kansas", Phone="0764-233445"},
            new Patient{PersonIDNr="19730111-5902", FirstName="Per", LastName="Chance", Address="Countryroad 20", Zipcode=12345, City="Kansas", Phone="0764-233445"},
            new Patient{PersonIDNr="19990117-1780", FirstName="Lars", LastName="Svensson", Address="Countryroad 20", Zipcode=12345, City="Kansas", Phone="0764-233445"},
            new Patient{PersonIDNr="19911129-7230", FirstName="Jan", LastName="Leversson", Address="Countryroad 20", Zipcode=12345, City="Kansas", Phone="0764-233445"},
            new Patient{PersonIDNr="19220217-4478", FirstName="Sara", LastName="Bloom", Address="Countryroad 20", Zipcode=12345, City="Kansas", Phone="0764-233445"},
            new Patient{PersonIDNr="19540303-1096", FirstName="Tina", LastName="Turner", Address="Countryroad 20", Zipcode=12345, City="Kansas", Phone="0764-233445"},
            new Patient{PersonIDNr="19751224-2967", FirstName="Philip", LastName="Fredag", Address="Countryroad 20", Zipcode=12345, City="Kansas", Phone="0764-233445"},
            new Patient{PersonIDNr="19830617-4589", FirstName="Freya", LastName="Svensson", Address="Countryroad 20", Zipcode=12345, City="Kansas", Phone="0764-233445"},
            };

            patients.ForEach(s => context.Patients.Add(s));
            context.SaveChanges();
            var rooms = new List<Room>
            {
            new Room{RoomID="P101", Capacity=5, Max_Capacity=8},
            new Room{RoomID="P102", Capacity=2, Max_Capacity=2},
            new Room{RoomID="P103", Capacity=6, Max_Capacity=8},
            new Room{RoomID="P104", Capacity=1, Max_Capacity=4},
            new Room{RoomID="P105", Capacity=8, Max_Capacity=12},
            };
            rooms.ForEach(s => context.Rooms.Add(s));
            context.SaveChanges();

            var registrations = new List<Registration>
            {
            new Registration{RegistrationID=1, RoomID="P101", PatientPersonIDNr="19880213-3478"},
            };
            registrations.ForEach(s => context.Registrations.Add(s));
            context.SaveChanges();
        }
    }
}