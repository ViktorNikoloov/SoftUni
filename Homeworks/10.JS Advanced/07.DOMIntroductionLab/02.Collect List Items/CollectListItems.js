function extractText() {
    const liElements = [...document.getElementsByTagName('li')];
    const elementText = liElements.map(e=>e.textContent);

    document.getElementById('result').value = elementText.join('\n');
}