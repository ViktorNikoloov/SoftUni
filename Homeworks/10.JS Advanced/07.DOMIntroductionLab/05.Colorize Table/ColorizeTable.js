function colorize() {
    // const rows = document.querySelectorAll('table tr');
    // for(let i = 1; i < rows.length; i+=2){
    //     rows[i].style.backgroundColor = 'teal';
    // }
    [...document.querySelectorAll('table tr:nth-child(even)')].forEach(c=>c.style.backgroundColor = 'teal');
}