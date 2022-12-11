namespace VaccOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;
    using Interfaces;

    public class VaccDb : IVaccOps
    {
        private Dictionary<string, Doctor> doctorsByName = new Dictionary<string, Doctor>();
        private Dictionary<string, Patient> patientsByname = new Dictionary<string, Patient>();

        public void AddDoctor(Doctor doctor)
        {
            if (this.doctorsByName.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();
            }

            this.doctorsByName.Add(doctor.Name, doctor);
        }

        public void AddPatient(Doctor doctor, Patient patient)
        {
            if (!this.doctorsByName.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();
            }

            if (this.patientsByname.ContainsKey(patient.Name))
            {
                throw new ArgumentException();
            }
            patient.Doctor = doctor;

            this.patientsByname.Add(patient.Name, patient);
            this.doctorsByName[doctor.Name].Patients.Add(patient);
        }

        public void ChangeDoctor(Doctor oldDoctor, Doctor newDoctor, Patient patient)
        {
            if (!this.Exist(oldDoctor) || !this.Exist(newDoctor) || !this.Exist(patient))
            {
                throw new ArgumentException();
            }

            oldDoctor.Patients.Remove(patient);
            newDoctor.Patients.Add(patient);
            patient.Doctor = newDoctor;
        }

        public bool Exist(Doctor doctor)
        => this.doctorsByName.ContainsKey(doctor.Name);

        public bool Exist(Patient patient)
        => this.patientsByname.ContainsKey(patient.Name);

        public IEnumerable<Doctor> GetDoctors()
        => this.doctorsByName.Values;

        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry)
        => this.doctorsByName.Values.Where(x => x.Popularity == populariry);

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
        => this.GetDoctors()
            .OrderByDescending(x => x.Patients.Count)
            .ThenBy(x => x.Name);

        public IEnumerable<Patient> GetPatients()
        => this.patientsByname.Values;

        public IEnumerable<Patient> GetPatientsByTown(string town)
        => this.GetPatients().Where(x => x.Town == town);

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
        => this.GetPatients().Where(x => x.Age >= lo && x.Age <= hi);

        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
            => this.GetPatients()
            .OrderBy(x => x.Doctor.Popularity)
            .ThenByDescending(x => x.Height)
            .ThenBy(x => x.Age);

        public Doctor RemoveDoctor(string name)
        {
            if (!this.doctorsByName.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            this.doctorsByName.Remove(name, out Doctor doctor);

            doctor.Patients.Select(x => this.patientsByname.Remove(x.Name));

            foreach (var patient in doctor.Patients)
            {
                this.patientsByname.Remove(patient.Name);
            }
            doctor.Patients.Clear();

            return doctor;
        }
    }
}
