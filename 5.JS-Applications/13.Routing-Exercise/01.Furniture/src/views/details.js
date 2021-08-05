import { html } from '../../node_modules/lit-html/lit-html.js';
import { deleteFurniture, getItemByID, getMyFurniture } from '../api/data.js';

const detailsTemplate = (item, isOwner, onDelete) => html`
<div class="row space-top">
            <div class="col-md-12">
                <h1>Furniture Details</h1>
            </div>
        </div>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src=${item.img} />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <p>Make: <span>${item.make}</span></p>
                <p>Model: <span>${item.model}</span></p>
                <p>Year: <span>${item.year}</span></p>
                <p>Description: <span>${item.description}</span></p>
                <p>Price: <span>${item.price}</span></p>
                <p>Material: <span>${item.material}</span></p>
                ${isOwner ? html`
                <div>
                    <a href=${`/edit/${item._id}`} class="btn btn-info">Edit</a>
                    <a @click=${onDelete} href="javascript:void(0)" class="btn btn-red">Delete</a>
                </div>` : ''}
            </div>
        </div>`;

export async function detailsPage(context) {
    const id = context.params.id;
    const item = await getItemByID(id);

    const userID = sessionStorage.getItem('userId');

    context.render(detailsTemplate(item, item._userId == userID, onDelete));

    async function onDelete() {
        const confirmation = confirm('Are you sure you want to delete this item?');

        if (confirmation) {
            await deleteFurniture(item._id);
            context.page.redirect('/');
        }
    }
}