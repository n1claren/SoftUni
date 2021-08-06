import { html } from '../../node_modules/lit-html/lit-html.js';
import { getMemeByID, updateMeme } from '../api/data.js';

const editTemplate = (meme, onSubmit) => html`
<section id="edit-meme">
            <form @submit=${onSubmit} id="edit-form">
                <h1>Edit Meme</h1>
                <div class="container">
                    <label for="title">Title</label>
                    <input id="title" type="text" placeholder="Enter Title" name="title" .value=${meme.title}>
                    <label for="description">Description</label>
                    <textarea id="description" placeholder="Enter Description" name="description" .value=${meme.description}></textarea>
                    <label for="imageUrl">Image Url</label>
                    <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${meme.imageUrl}>
                    <input type="submit" class="registerbtn button" value="Edit Meme">
                </div>
            </form>
        </section>`;

export async function editPage(context) {
    const memeID = context.params.id;
    const meme = getMemeByID(memeID);
    context.render(editTemplate(meme, onSubmit));

    async function onSubmit(ev) {
        ev.preventDefault();

        const formData = new FormData(ev.target);

        const title = formData.get('title');
        const description = formData.get('description');
        const imageUrl = formData.get('imageUrl');

        if (!title || !description || !imageUrl) {
            return alert('All fields are required!');
        }

        await updateMeme(memeID, {
            title,
            description,
            imageUrl
        })

        context.page.redirect('/details/' + memeID);
    }
}