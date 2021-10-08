function addItem() {
    let text = document.getElementById('newItemText').value;
    let value = document.getElementById('newItemValue').value;

    let menu = document.getElementById('menu');
    let option = document.createElement('option');
    option.textContent = `${text}:${value}`;
    menu.appendChild(option);
    document.getElementById('newItemText').value = '';
    document.getElementById('newItemValue').value = '';
}