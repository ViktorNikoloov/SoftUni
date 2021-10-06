function solve() {
  let input = document.getElementById('input').value.split('.');
  let result = [];
  let currString = '';
  let counter = 0;
  while (input.length != 1) {
    counter++;
    if (counter == 1) {
      currString = '<p>'
    }
    currString += input.shift() + '.';

    if (counter === 3 || input.length === 1) {
      currString += '</p>'
      result.push(currString);
      counter = 0;
    }
  }
  document.getElementById('output').innerHTML = result.join('\n');

}