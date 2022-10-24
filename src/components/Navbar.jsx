import React from 'react'
import { Link } from 'react-router-dom'

const Navbar = () => {
    return (
        <nav className='layout__navbar'>
            <div className='navbar__section navbar__section--logo'>
                <Link to="/Home">
                    {/* <img src='' alt='' /> */}
                    <h1>Logo</h1>
                </Link>
            </div>
            <div className='navbar__section navbar__section--content'>
                <button href=''>Buy Membership</button>
                <button>
                    <Link to='/Lesson'>Shop</Link>
                </button>
                <button>
                    <Link to='/Login'>Login</Link>
                </button>
            </div>
        </nav>
    )
}

export default Navbar