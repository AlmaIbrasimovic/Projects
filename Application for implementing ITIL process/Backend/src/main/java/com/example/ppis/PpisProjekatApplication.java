package com.example.ppis;

import com.example.ppis.model.*;
import com.example.ppis.repository.*;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@SpringBootApplication
public class PpisProjekatApplication {
	private static final Logger log =
			LoggerFactory.getLogger(PpisProjekatApplication.class);

	public static void main(String[] args) {
		SpringApplication.run(PpisProjekatApplication.class, args);
	}

	@Bean
	public CommandLineRunner addData(UserRepository userRepository,
									 RoleRepository roleRepository,
									 SkillTypeRepository skillTypeRepository,
									 SkillRepository skillRepository,
									 EducationTypeRepository educationTypeRepository,
									 EducationRepository educationRepository,
									 EmployeeRepository employeeRepository,
									 EmployeeSkillRepository employeeSkillRepository,
									 SuplierRepository suplierRepository,
									 ContractRepository contractRepository,
									 CriteriaTypeRepository criteriaTypeRepository,
									 CertificateRepository certificateRepository,
									 GradeRepository gradeRepository,
									 EmployeeEducationRepository employeeEducationRepository) {
		return(args) -> {
			Role role1 = roleRepository.save(new Role("administrator"));
			Role role2 = roleRepository.save(new Role("hr_manager"));
			Role role3 = roleRepository.save(new Role("suplier_manager"));
			log.info("Sve uloge \n");
			for (Role role : roleRepository.findAll()) {
				log.info(role.getName());
			}
			log.info(" ");

			// korisnici
			List<Role> role = new ArrayList<>();
			role.add(role1);
			User k1 = userRepository.save(new User("admin", "$2y$12$d.WC//FFyNCsaGzHJhalAuH6EMbmKaPDHUWxGhiQvoghruwrUUjCm", "ante.antic@gmail.com", role));
			role = new ArrayList<>();
			role.add(role2);
			User k2 = userRepository.save(new User("hrmanager", "$2y$12$d.WC//FFyNCsaGzHJhalAuH6EMbmKaPDHUWxGhiQvoghruwrUUjCm", "amna.amnic@gmail.com", role));
			role = new ArrayList<>();
			role.add(role3);
			User k3 = userRepository.save(new User("supmanager", "$2y$12$d.WC//FFyNCsaGzHJhalAuH6EMbmKaPDHUWxGhiQvoghruwrUUjCm", "stevo.stevic@gmail.com", role));


			log.info("Svi korisnici \n");
			for (User user : userRepository.findAll()) {
				log.info(user.getUsername());
			}
			log.info(" ");

			//tipovi skilova
			List<SkillType> skillTypes = new ArrayList<>();
			SkillType skillType1 = skillTypeRepository.save(new SkillType("Razvoj softvera"));
			SkillType skillType2 = skillTypeRepository.save(new SkillType("Soft vještine"));
			SkillType skillType3 = skillTypeRepository.save(new SkillType("Mreže"));

			log.info("Svi tipovi vještina \n");
			for (SkillType skillType : skillTypeRepository.findAll()) {
				log.info(skillType.getName());
			}
			log.info(" ");

			//vještine
			Skill skill1 = skillRepository.save(new Skill("Java programiranje", skillType1));
			Skill skill2 = skillRepository.save(new Skill("React programiranje", skillType1));
			Skill skill3 = skillRepository.save(new Skill("Prezentacija", skillType2));
			Skill skill4 = skillRepository.save(new Skill("C# programiranje", skillType1));
			Skill skill5 = skillRepository.save(new Skill("C++ programiranje", skillType1));
			Skill skill6 = skillRepository.save(new Skill("Relacione baze podataka", skillType1));
			Skill skill7 = skillRepository.save(new Skill("Sigurnost", skillType3));
			Skill skill8 = skillRepository.save(new Skill("Komunikacione vještine", skillType2));
			Skill skill9 = skillRepository.save(new Skill("Liderstvo", skillType2));

			log.info("Sve vještine \n");
			for (Skill skill : skillRepository.findAll()) {
				log.info(skill.getName() + " Tip vještine: " + skill.getSkillType().getName());
			}
			log.info(" ");

			//tipovi edukacije
			EducationType educationType1 = educationTypeRepository.save(new EducationType("Interna"));
			EducationType educationType2 = educationTypeRepository.save(new EducationType("Eksterna"));

			log.info("Svi tipovi edukacija \n");
			for (EducationType educationType : educationTypeRepository.findAll()) {
				log.info(educationType.getName());
			}
			log.info(" ");

			//edukacije
			Education education1 = educationRepository.save(new Education(skill1, educationType1, "Java for Beginners", "Niko Nikic", new Date()));
			Education education2 = educationRepository.save(new Education(skill2, educationType2, "React for beginners", "Marko Markovic", new Date()));
			Education education3 = educationRepository.save(new Education(skill7, educationType1, "Network security", "Snezana Snezic", new Date()));
			Education education4 = educationRepository.save(new Education(skill9, educationType2, "Seminar for scrum masters", "Nina Ninic", new Date()));
			Education education5 = educationRepository.save(new Education(skill4, educationType1, "ASP.NET 3.0", "Dino Dinic", new Date()));

			log.info("Sve edukacije \n");
			for (Education education : educationRepository.findAll()) {
				log.info(education.toString());
			}
			log.info(" ");

			//uposlenici
			Employee employee1 = employeeRepository.save(new Employee("Ivo", "Ivic", new Date(), new Date()));
			Employee employee2 = employeeRepository.save(new Employee("Maja", "Majic", new Date(), new Date()));
			Employee employee3 = employeeRepository.save(new Employee("Stevo", "Stevic", new Date(), new Date()));
			Employee employee4 = employeeRepository.save(new Employee("Ahmo", "Ahmic", new Date(), new Date()));

			log.info("Svi uposlenici \n");
			for (Employee employee : employeeRepository.findAll()) {
				log.info(employee.getFirstName() + " " + employee.getLastName());
			}
			log.info(" ");

			//Edukcije na uposlenicima

			EmployeeEducation employeeEducation1 = employeeEducationRepository.save(new EmployeeEducation(employee1, education1));
			EmployeeEducation employeeEducation2 = employeeEducationRepository.save(new EmployeeEducation(employee1, education2));
			EmployeeEducation employeeEducation3 = employeeEducationRepository.save(new EmployeeEducation(employee1, education4));

			EmployeeEducation employeeEducation4 = employeeEducationRepository.save(new EmployeeEducation(employee2, education2));
			EmployeeEducation employeeEducation5 = employeeEducationRepository.save(new EmployeeEducation(employee2, education4));

			EmployeeEducation employeeEducation7 = employeeEducationRepository.save(new EmployeeEducation(employee4, education3));

			//skillovi kod uposlenika

			EmployeeSkill employeeSkill1 = employeeSkillRepository.save(new EmployeeSkill(employee1, skill1, 5, new Date()));
			EmployeeSkill employeeSkill2 = employeeSkillRepository.save(new EmployeeSkill(employee1, skill2, 5, new Date()));
			EmployeeSkill employeeSkill3 = employeeSkillRepository.save(new EmployeeSkill(employee1, skill4, 3, new Date()));
			EmployeeSkill employeeSkill4 = employeeSkillRepository.save(new EmployeeSkill(employee1, skill5, 4, new Date()));

			EmployeeSkill employeeSkill5 = employeeSkillRepository.save(new EmployeeSkill(employee2, skill2, 5, new Date()));
			EmployeeSkill employeeSkill6 = employeeSkillRepository.save(new EmployeeSkill(employee2, skill3, 5, new Date()));
			EmployeeSkill employeeSkill7 = employeeSkillRepository.save(new EmployeeSkill(employee2, skill9, 5, new Date()));
			EmployeeSkill employeeSkill8 = employeeSkillRepository.save(new EmployeeSkill(employee2, skill8, 4, new Date()));

			EmployeeSkill employeeSkill11 = employeeSkillRepository.save(new EmployeeSkill(employee4, skill5, 5, new Date()));
			EmployeeSkill employeeSkill12 = employeeSkillRepository.save(new EmployeeSkill(employee4, skill6, 5, new Date()));
			EmployeeSkill employeeSkill9 = employeeSkillRepository.save(new EmployeeSkill(employee4, skill7, 3, new Date()));
			EmployeeSkill employeeSkill10 = employeeSkillRepository.save(new EmployeeSkill(employee4, skill8, 4, new Date()));

			log.info("Svi skilovi uposlenika \n");
			for (EmployeeSkill employeeSkill : employeeSkillRepository.findAll()) {
				log.info(employeeSkill.getSkill().getName());
			}
			log.info(" ");

			//Dobavljaci

			Suplier suplier1 = suplierRepository.save(new Suplier("HP", "Adresa1", "Niko Nikic"));
			Suplier suplier2 = suplierRepository.save(new Suplier("Import-Eksport", "Adresa 55", "Savo Savic"));
			Suplier suplier3 = suplierRepository.save(new Suplier("Iron Man Processors", "Adresa 153", "Stipo Stipic"));

			log.info("Dobavljaci \n");
			for (Suplier suplier : suplierRepository.findAll()) {
				log.info(suplier.getName());
			}
			log.info(" ");

			//Ugovori

			Contract contract1 = contractRepository.save(new Contract(suplier1, "Ugovor o nabavci laptopa", new Date(), new Date()));
			Contract contract2 = contractRepository.save(new Contract(suplier1, "Ugovor o nabavci slusalica", new Date(), new Date()));
			Contract contract3 = contractRepository.save(new Contract(suplier3, "Ugovor o nabavci procesora", new Date(), new Date()));

			log.info("Ugovori \n");
			for (Contract contract : contractRepository.findAll()) {
				log.info(contract.getName() + " Dobavljac: " + contract.getSuplier().getName());
			}
			log.info(" ");

			//Tipovi kriterija za ocjenjivanje

			CriteriaType criteriaType1 = criteriaTypeRepository.save(new CriteriaType("Cijena", 2.));
			CriteriaType criteriaType2 = criteriaTypeRepository.save(new CriteriaType("Brzina dostave", 2.));
			CriteriaType criteriaType3 = criteriaTypeRepository.save(new CriteriaType("Komunikacija", 1.));

			log.info("Kriteriji ocjenjivanja \n");
			for (CriteriaType criteriaType : criteriaTypeRepository.findAll()) {
				log.info(criteriaType.getName() + " Koeficijent: " + criteriaType.getCoeficient());
			}
			log.info(" ");

			//Ocjene
			Grade grade11 = gradeRepository.save(new Grade(criteriaType1, suplier1, k3, new Date(), 5, 2018));
			Grade grade12 = gradeRepository.save(new Grade(criteriaType2, suplier1, k3, new Date(), 2, 2018));
			Grade grade13 = gradeRepository.save(new Grade(criteriaType3, suplier1, k3, new Date(), 5, 2018));

			Grade grade21 = gradeRepository.save(new Grade(criteriaType1, suplier2, k3, new Date(), 4, 2018));
			Grade grade22 = gradeRepository.save(new Grade(criteriaType2, suplier2, k3, new Date(), 4, 2018));
			Grade grade23 = gradeRepository.save(new Grade(criteriaType3, suplier2, k3, new Date(), 2, 2018));

			Grade grade31 = gradeRepository.save(new Grade(criteriaType1, suplier3, k3, new Date(), 2, 2018));
			Grade grade32 = gradeRepository.save(new Grade(criteriaType2, suplier3, k3, new Date(), 5, 2018));
			Grade grade33 = gradeRepository.save(new Grade(criteriaType3, suplier3, k3, new Date(), 3, 2018));

			Grade grade119 = gradeRepository.save(new Grade(criteriaType1, suplier1, k3, new Date(), 5, 2019));
			Grade grade129 = gradeRepository.save(new Grade(criteriaType2, suplier1, k3, new Date(), 3, 2019));
			Grade grade139 = gradeRepository.save(new Grade(criteriaType3, suplier1, k3, new Date(), 5, 2019));

			Grade grade219 = gradeRepository.save(new Grade(criteriaType1, suplier2, k3, new Date(), 5, 2019));
			Grade grade229 = gradeRepository.save(new Grade(criteriaType2, suplier2, k3, new Date(), 5, 2019));
			Grade grade239 = gradeRepository.save(new Grade(criteriaType3, suplier2, k3, new Date(), 2, 2019));

			Grade grade319 = gradeRepository.save(new Grade(criteriaType1, suplier3, k3, new Date(), 2, 2019));
			Grade grade329 = gradeRepository.save(new Grade(criteriaType2, suplier3, k3, new Date(), 3, 2019));
			Grade grade339 = gradeRepository.save(new Grade(criteriaType3, suplier3, k3, new Date(), 3, 2019));

			//Svi certifikati

			Certificate certificate1 = certificateRepository.save(new Certificate(employee1, skill7, "CISCO", new Date(), new Date()));
			Certificate certificate2 = certificateRepository.save(new Certificate(employee1, skill1, "Oracle Certified Associate Java Programmer", new Date(), new Date()));

			Certificate certificate3 = certificateRepository.save(new Certificate(employee2, skill9, "Scrum Master", new Date(), new Date()));
		};
	}


}
