  function sortAnArrayBy2Criteria(arr){
    return arr.sort((a,b) => {
        if (a.length === b.length) {
            return a.localeCompare(b);
        }

        return a.length - b.length;
    }).join('\n')
  }

  console.log(sortAnArrayBy2Criteria(['alpha', 'beta', 'gamma']));
  console.log(sortAnArrayBy2Criteria(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']));
  console.log(sortAnArrayBy2Criteria(['alpha', 'beta', 'gamma']));