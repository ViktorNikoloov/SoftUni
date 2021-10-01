function search() {
   let liItems = document.querySelectorAll('ul li');
   const searchText = document.getElementById('searchText').value.toLowerCase();

   let counter = 0;
   for (const li of liItems) {
      let currLiElement = li.textContent.toLowerCase();
      if (currLiElement.includes(searchText)) {
         li.style.fontWeight = 'bold';
         li.style.textDecoration = 'underline';
         counter++;
      }
   }

   document.getElementById('result').textContent = `${counter} matches found`;
}
