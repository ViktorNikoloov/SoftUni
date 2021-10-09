function solve() {
  let tbodyElement = document.querySelector('tbody');
  

  document.addEventListener('click', (ev) => {
    if (ev.target.textContent == 'Generate') {
      let furnitures = JSON.parse(document.getElementsByTagName('textarea')[0].value);

      for (let i = 0; i < furnitures.length; i++) {
        let currFurniture = furnitures[i];
        createTrElementIntoTable(currFurniture);

      }
      let allChecked = document.querySelectorAll('input[type=checkbox]');
      [...allChecked].map(x=>x.disabled = false)

    } else if(ev.target.textContent == 'Buy'){
      let resultTextBox = document.getElementsByTagName('textarea')[1];

      let allCheckedFurnitures = [...document.querySelectorAll('tr')].filter(x=>x.querySelector('input[type=checkbox]:checked'));
      let allCheckedNames = [];
      let totalPrice = 0;
      let AvgDecFactor = 0;
      let counter = 0;
      
      allCheckedFurnitures.forEach(e => {
        allCheckedNames.push(e.querySelectorAll('td p')[0].textContent);
        totalPrice += Number(e.querySelectorAll('td p')[1].textContent)
        AvgDecFactor += Number(e.querySelectorAll('td p')[2].textContent)
        counter++;
      });

      resultTextBox.value = (`Bought furniture: ${allCheckedNames.join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${Number(AvgDecFactor / 2)}`); 
    }
  })


  function createTrElementIntoTable(obj) {
    let trElement = createElement('tr');

    let tdImgElement = createElement('td');
    let imageElement = createElement('img');
    imageElement.src = obj.img;
    tdImgElement.appendChild(imageElement);

    let tdNameElement = createElement('td');
    let nameParagraph = createElement('p');
    nameParagraph.textContent = obj.name;
    tdNameElement.appendChild(nameParagraph);

    let tdPriceElement = createElement('td');
    let priceParagraph = createElement('p');
    priceParagraph.textContent = Number(obj.price);
    tdPriceElement.appendChild(priceParagraph);

    let tdFactorElement = createElement('td');
    let factorParagraph = createElement('p');
    factorParagraph.textContent = Number(obj.decFactor);
    tdFactorElement.appendChild(factorParagraph);

    let tdCheckboxElement = createElement('td');
    let checkboxInput = createElement('input');
    checkboxInput.setAttribute("type", "checkbox");
    checkboxInput.disabled = true;
    tdCheckboxElement.appendChild(checkboxInput);

    trElement.appendChild(tdImgElement);
    trElement.appendChild(tdNameElement);
    trElement.appendChild(tdPriceElement);
    trElement.appendChild(tdFactorElement);
    trElement.appendChild(tdCheckboxElement);

    tbodyElement.appendChild(trElement);
  }

  function createElement(element) {
    return document.createElement(element);
  }

}