function generateReport() {
    let inputElements = [...document.getElementsByTagName('input')];
    let tableRows = [...document.getElementsByTagName('tr')];
 
    const result = [];
    const checked = [];
 
    for (let i = 0; i < tableRows.length; i++) {
        const row = tableRows[i];
        const obj = {};
 
        for (let j = 0; j < row.children.length; j++) {
            const element = row.children[j];
            if (i == 0) {
                if (element.children[0].checked) {
                    checked.push(j);
                }
                continue;
            }
 
            if (checked.includes(j)) {
                let propertyName = inputElements[j].name;
                obj[propertyName] = element.textContent;
            }
        }
        if (i !== 0) {
            result.push(obj);
        }
    } 
    document.getElementById('output').value = JSON.stringify(result);
}