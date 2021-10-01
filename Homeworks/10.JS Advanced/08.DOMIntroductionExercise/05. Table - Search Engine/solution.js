function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   const rows = document.querySelectorAll('tbody tr');

   function onClick() {
      const input = document.getElementById('searchField').value;
      for (const row of rows) {
         if (row.textContent.includes(input)) {
            // row.classList.add('select');
            row.setAttribute('class', 'select')
         } else{
            row.removeAttribute('select');
         }
      }
   }
}