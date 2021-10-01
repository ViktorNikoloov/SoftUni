function solve() {
  const text = document.getElementById('text').value.toLowerCase().split(' ');
  const convention = document.getElementById('naming-convention').value;

  let result = '';

  if (convention === 'Pascal Case') {
    for (const word of text) {
      result += word[0].toUpperCase() + word.substring(1);
    }
  } else if(convention === 'Camel Case'){
    for(let i = 0; i< text.length;i++){
      if (i === 0) {
        result += text[i]
      } else{
        result += text[i][0].toUpperCase() + text[i].substring(1);
      }
    }
  } else{
    result = 'Error!';
  }

  document.getElementById('result').textContent = result;

}