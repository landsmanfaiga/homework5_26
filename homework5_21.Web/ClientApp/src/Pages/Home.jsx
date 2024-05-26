import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Home = () => {

    const [coloringBooks, setColoringBooks] = useState([]);

    useEffect(() => {
        getColoringBooks();
    }, []);

    const getColoringBooks = async() => {
        const { data } = await axios.get('/api/scraping/getcoloringbooks')
        setColoringBooks(data);
    }
    
    return (
        <div>
                <table className="table table-bordered">
                    <thead>
                        <tr>
                            <th>Image</th>
                            <th>Title</th>
                            <th>Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        {coloringBooks.map(item => (
                            <tr key={item.title}>
                                <td><img src={item.image} alt={item.title} className="img-thumbnail" /></td>
                                <td>
                                    <a href={item.url} target='_blank'>
                                        {item.title}
                                    </a>
                                </td>
                                <td>{item.price}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
        </div>
    );
};

export default Home;