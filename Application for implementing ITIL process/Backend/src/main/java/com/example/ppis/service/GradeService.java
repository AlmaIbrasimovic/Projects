package com.example.ppis.service;

import com.example.ppis.dto.SuplierGradeDto;
import com.example.ppis.dto.SuplierGradeObjectDto;
import com.example.ppis.model.Certificate;
import com.example.ppis.model.Grade;
import com.example.ppis.model.Suplier;
import com.example.ppis.repository.GradeRepository;
import com.example.ppis.repository.SuplierRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

@Service
public class GradeService {

    @Autowired
    GradeRepository gradeRepository;

    @Autowired
    SuplierRepository suplierRepository;

    public Grade add(Grade grade)  {
        return gradeRepository.save(grade);
    }

    public List<Grade> getAllGrades() throws Exception {
        List<Grade> grades = new ArrayList<>();
        if(gradeRepository.count() == 0) {
            throw new Exception("Nema ocjena u bazi");
        }
        gradeRepository.findAll().forEach(grades::add);
        return grades;
    }

    public List<Grade> getAllGradesForSuplier(Integer suplierId) throws Exception {
        List<Grade> grades = getAllGrades();
        List<Grade> gradesForSuplier = new ArrayList<>();
        for(int i=0; i < grades.size(); i++) {
            if(grades.get(i).getSuplier().getId() == suplierId) {
                gradesForSuplier.add(grades.get(i));
            }
        }
        return gradesForSuplier;
    }

    public SuplierGradeObjectDto getStatistic() throws Exception {
        List<Grade> all = getAllGrades();

        List<Integer> yearsAll = new ArrayList<>();
        List<Integer> supliersAll = new ArrayList<>();
        for(int i=0; i<all.size(); i++) {
            yearsAll.add(all.get(i).getYear());
            supliersAll.add(all.get(i).getSuplier().getId());
        }

        Set<Integer> yearsSet = new HashSet<Integer>(yearsAll);
        Set<Integer> supliersSet = new HashSet<Integer>(supliersAll);

        List<Integer> years = new ArrayList<>(yearsSet);
        List<Integer> supliers = new ArrayList<>(supliersSet);

        List<SuplierGradeDto> suplierGradeDtos = new ArrayList<>();

        for(int i=0; i<supliers.size(); i++) {
            for(int j=0; j<years.size(); j++) {
                List<Grade> ocjene = new ArrayList<>();
                Double finalna = 0.;
                for(int k=0; k<all.size(); k++) {
                    Integer pom1 = all.get(k).getYear();
                    Integer pom2 = years.get(j);
                    Integer pom3 = all.get(k).getSuplier().getId();
                    Integer pom4 = supliers.get(i);
                    if(all.get(k).getYear().intValue()==years.get(j).intValue() && all.get(k).getSuplier().getId().intValue() == supliers.get(i).intValue()) {
                        ocjene.add(all.get(k));
                        finalna+=all.get(k).getGrade()*all.get(k).getCriteriaType().getCoeficient();
                    }
                }
                Suplier supName = suplierRepository.findById(supliers.get(i)).orElse(null);
                suplierGradeDtos.add(new SuplierGradeDto(supliers.get(i), supName.getName(), ocjene, finalna, years.get(j)));
            }
        }


        return new SuplierGradeObjectDto(suplierGradeDtos, supliers, years);
    }

    public List<Grade> getAllGradesFromUser(Integer userId) throws Exception {
        List<Grade> grades = getAllGrades();
        List<Grade> gradesFromUser = new ArrayList<>();
        for(int i=0; i < grades.size(); i++) {
            if(grades.get(i).getUser().getId() == userId) {
                gradesFromUser.add(grades.get(i));
            }
        }
        return gradesFromUser;
    }

    public void deleteGradesForSuplier(Integer suplierId) throws Exception{
        List<Grade> suplierGrades = getAllGradesForSuplier(suplierId);
        for (int i = 0; i < suplierGrades.size(); i++) {
            gradeRepository.deleteById(suplierGrades.get(i).getId());
        }
    }

    public void deleteGradesFromUser(Integer userId) throws Exception{
        List<Grade> userGrades = getAllGradesFromUser(userId);
        for (int i = 0; i < userGrades.size(); i++) {
            gradeRepository.deleteById(userGrades.get(i).getId());
        }
    }

    public Float getFinalGradeForSuplier(Integer suplierId) throws Exception {
        List<Grade> grades = getAllGradesForSuplier(suplierId);
        Float finalGrade = 0f;
        for (Grade grade: grades) {
            finalGrade += grade.getGrade();
        }
        finalGrade /= grades.size();
        return finalGrade;
    }
}
