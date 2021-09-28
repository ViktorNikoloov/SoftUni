function constructionCrew(worker){
 const result = worker;
 const requiredWaterPerMl = 0.1;
    let hasDizziness = worker.dizziness;
    if (hasDizziness) {
        let weight = worker.weight;
        let exp = worker.experience;
        let intakeWater = requiredWaterPerMl * weight * exp;

        worker.levelOfHydrated += intakeWater;
        worker.dizziness = false;

    }

    return result;
}

console.log(constructionCrew({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true }
  ));

  console.log(constructionCrew({ weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true }
  ));

  console.log(constructionCrew({ weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false }
  
  ));