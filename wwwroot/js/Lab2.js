const uri = 'api/Films';
let films = [];

function getFilms() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayFilms(data))
        .catch(error => console.error('Unable to get films.', error));
}

function addFilm() {
    const addTitleTextbox = document.getElementById('add-title');
    const addYearTextbox = document.getElementById('add-year');
    const addRunTimeTextbox = document.getElementById('add-runtime');
    const addDescriptionTextbox = document.getElementById('add-info');
    const addDirectorTextbox = document.getElementById('add-director');

    const film = {
        title: addTitleTextbox.value.trim(),
        year: addYearTextbox.value.trim(),
        runtime: addRunTimeTextbox.value.trim(),
        description: addDescriptionTextbox.value.trim(),
        director: addDirectorTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(film)
    })
        .then(response => response.json())
        .then(() => {
            getFilms();
            addaddTitleTextbox.value = '';
            addYearTextbox.value = '';
            addRunTimeTextbox.value = '';
            addInfoTextbox.value = '';
            addDirectorTextbox.value = '';
        })
        .catch(error => console.error('Unable to add film.', error));
}

function deleteFilm(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getFilms())
        .catch(error => console.error('Unable to delete film.', error));
}

function displayEditForm(id) {
    const film = films.find(film => film.id === id);

    document.getElementById('edit-id').value = film.id;
    document.getElementById('edit-title').value = film.title;
    document.getElementById('edit-year').value = film.year;
    document.getElementById('edit-runtime').value = film.runtime;
    document.getElementById('edit-info').value = category.description;
    document.getElementById('edit-director').value = category.director;
    document.getElementById('editForm').style.display = 'block';
}

function updateFilm() {
    const filmId = document.getElementById('edit-id').value;
    const film = {
        id: parseInt(filmId, 10),
        title: document.getElementById('edit-title').value.trim(),
        year: document.getElementById('edit-year').value.trim(),
        runtime: document.getElementById('edit-runtime').value.trim(),
        description: document.getElementById('edit-info').value.trim(),
        director: document.getElementById('edit-director').value.trim()
    };

    fetch(`${uri}/${filmId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(film)
    })
        .then(() => getFilms())
        .catch(error => console.error('Unable to update film.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayFilms(data) {
    const tBody = document.getElementById('films');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(film => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${film.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteFilm(${film.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(film.title);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNode = document.createTextNode(film.year);
        td2.appendChild(textNodeYear);

        let td3 = tr.insertCell(2);
        let textNode = document.createTextNode(film.runtime);
        td3.appendChild(textNodeRunTime);

        let td4 = tr.insertCell(3);
        let textNodeInfo = document.createTextNode(film.description);
        td4.appendChild(textNodeDescription);

        let td5 = tr.insertCell(4);
        let textNodeInfo = document.createTextNode(film.director);
        td5.appendChild(textNodeDirector);

        let td6 = tr.insertCell(5);
        td6.appendChild(editButton);

        let td7 = tr.insertCell(6);
        td7.appendChild(deleteButton);
    });

    films = data;
}
