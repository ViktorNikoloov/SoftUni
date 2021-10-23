window.addEventListener('load', solve);

function solve() {
    const fields = document.querySelectorAll('.container-text input');
    const addButton = document.querySelector('.container-text button');
    const allHits = document.querySelector('#all-hits div');
    const savedHits = document.querySelector('#saved-hits div');
    const totalLikes = document.querySelector('#total-likes div');

    // console.log(fields);
    // console.log(addButton);
    // console.log(allHits);
    // console.log(savedHits);
    // console.log(totalLikes);
    const input = {
        genre: fields[0],
        name: fields[1],
        author: fields[2],
        date: fields[3],
    }

    addButton.addEventListener('click', (event) => {
        event.preventDefault();

        const genre = input.genre.value.trim();
        const name = input.name.value.trim();
        const author = input.author.value.trim();
        const date = input.date.value.trim();

        if (genre == '' || name == '' || author == '' || date == '') {
            return;
        }

        const divEl = e('div', ``, 'hits-info');
        const imgEl = e('img', './static/img/img.png');
        const genreEl = e('h2', `Genre: ${genre}`);
        const nameEl = e('h2', `Name: ${name}`);
        const authorEl = e('h2', `Author: ${author}`);
        const dateEl = e('h3', `Date: ${date}`);
        const saveSongBtn = e('button', 'Save song', 'save-btn');
        const likeSongBtn = e('button', 'Like song', 'like-btn');
        const deleteSongBtn = e('button', 'Delete', 'delete-btn');

        divEl.appendChild(imgEl);
        divEl.appendChild(genreEl);
        divEl.appendChild(nameEl);
        divEl.appendChild(authorEl);
        divEl.appendChild(dateEl);
        divEl.appendChild(saveSongBtn);
        divEl.appendChild(likeSongBtn);
        divEl.appendChild(deleteSongBtn);

        allHits.appendChild(divEl);

        input.genre.value = '';
        input.name.value = '';
        input.author.value = '';
        input.date.value = '';

        likeSongBtn.addEventListener('click', () => {
            let pEl = totalLikes.querySelector('p').textContent;
            let newLikes = Number(pEl.slice(-1)) + 1;
            totalLikes.querySelector('p').textContent = pEl.substr(0, pEl.length - 1) + newLikes;
            likeSongBtn.disabled = true;

        })

        saveSongBtn.addEventListener('click', () => {
            const saveSongDivEl = e('div', ``, 'hits-info');
            saveSongDivEl.appendChild(imgEl);
            saveSongDivEl.appendChild(genreEl);
            saveSongDivEl.appendChild(nameEl);
            saveSongDivEl.appendChild(authorEl);
            saveSongDivEl.appendChild(dateEl);
            saveSongDivEl.appendChild(deleteSongBtn);

            savedHits.appendChild(saveSongDivEl);
            saveSongBtn.parentNode.parentNode.removeChild(divEl);;

        })

        deleteSongBtn.addEventListener('click', () => {
            let divForDelete = deleteSongBtn.parentNode;
            deleteSongBtn.parentNode.parentNode.removeChild(divForDelete);

            let pEl = totalLikes.querySelector('p').textContent;
            let newLikes = Number(pEl.slice(-1)) - 1;
            totalLikes.querySelector('p').textContent = pEl.substr(0, pEl.length - 1) + newLikes;
        })


    })

    function e(type, content, className) {
        let element = document.createElement(type);

        if (type === 'img') {
            element.src = content;
        } else {
            element.textContent = content;
        }

        if (className) {
            element.className = className;
        }

        return element;
    }
}