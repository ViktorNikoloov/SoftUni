function create(words) {
   let content = document.getElementById('content');

   for (let i = 0; i < words.length; i++) {
      let divElement = document.createElement('div');
      let pElement = document.createElement('p');
      pElement.style.display = "none";
      pElement.textContent = words[i];
      content.appendChild(divElement).appendChild(pElement);
   }

   content.addEventListener('click', (ev) => {
      ev.target.querySelector('p').style.display = '';
   })

}