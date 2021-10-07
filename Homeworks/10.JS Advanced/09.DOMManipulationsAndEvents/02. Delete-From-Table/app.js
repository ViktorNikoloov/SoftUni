function deleteByEmail() {
    let input = document.querySelector('input[name="email"]').value;
    let rows = [...document.querySelectorAll('tbody tr')];
    let matched = false;
    for (const row of rows) {
        if(row.children[1].textContent === input){
            row.parentNode.removeChild(row);
            document.getElementById('result').textContent = 'Deleted.';
            continue;
        }

        document.getElementById('result').textContent = 'Not found.';
    }
}