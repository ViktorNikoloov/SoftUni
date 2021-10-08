function lockedProfile() {
    document.getElementById('main').addEventListener('click', (ev) => {
        let profile = ev.target.parentNode;
        let textToBeShown = profile.querySelector('div');
        let isLock = profile.querySelectorAll('input[type=radio]:checked')[0].value === 'lock';

        if (!isLock) {
            if (ev.target.tagName == 'BUTTON') {
                if (ev.target.textContent == 'Show more') {
                    ev.target.textContent = 'Hide it';
                    textToBeShown.style.display = 'block';

                } else {
                    ev.target.textContent = 'Show more';
                    textToBeShown.style.display = 'none';
                }
            }
        }
    })
}