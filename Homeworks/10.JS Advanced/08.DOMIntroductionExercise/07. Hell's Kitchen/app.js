function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let input = JSON.parse(document.querySelector('#inputs>textarea').value);
      let restaurants = {};

      for (let i = 0; i < input.length; i++) {
         let tokens = input[i].split(' - ').filter(x => x != '');
         let restaurantName = tokens[0];
         let workersArr = tokens[1].split(', ');

         let workers = [];
         let averageSalary = 0;
         let bestSalary = 0;
         for (let j = 0; j < workersArr.length; j++) {
            const workersToken = workersArr[j].split(' ')
            const workerName = workersToken[0];
            const salary = Number(workersToken[1]);
            workers.push({ name: workerName, salary });

         }

         if (restaurants[restaurantName]) {
            workers = workers.concat(restaurants[restaurantName].workers);
         }

         workers.sort((workerOne, workerTwo) => workerTwo.salary - workerOne.salary);
         bestSalary = workers[0].salary;
         averageSalary = workers.reduce((sum, worker) => sum + worker.salary, 0) / workers.length;

         restaurants[restaurantName] = {
            workers,
            averageSalary,
            bestSalary
         }

      }

      let theBestRestaurantSalary = 0;
      let theBestRestaurant = undefined;
      for (const name in restaurants) {
         if (restaurants[name].averageSalary > theBestRestaurantSalary) {
            theBestRestaurantSalary = restaurants[name].averageSalary;
            theBestRestaurant = {
               name,
               workers: restaurants[name].workers,
               bestSalary: restaurants[name].bestSalary,
               averageSalary: restaurants[name].averageSalary
            }
            theBestRestaurantSalary = restaurants[name].averageSalary
         }
      }

      
      document.querySelector('#bestRestaurant>p').textContent = `Name: ${theBestRestaurant.name} Average Salary: ${theBestRestaurant.averageSalary.toFixed(2)} Best Salary: ${theBestRestaurant.bestSalary.toFixed(2)}`;

      let workersResult = [];
       theBestRestaurant.workers.forEach(worker=>
         workersResult.push(`Name: ${worker.name} With Salary: ${worker.salary}`))

      console.log(workersResult);
      document.querySelector('#workers>p').textContent = workersResult.join(' ');
   }
}