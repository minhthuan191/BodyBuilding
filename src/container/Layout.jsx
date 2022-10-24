import React from 'react'
import { BrowserRouter, Outlet, Route } from 'react-router-dom';
import { Routes } from 'react-router-dom'

// Components
import Navbar from '../components/Navbar';
import Footer from '../components/Footer';


// Pages
import Home from '../pages/Home';
import Login from '../pages/Login';
import LessonList from '../pages/LessonList';

function Layout4Route() {
    return (
        <div className='layout__container'>
            <header className='layout__navbar' >
                <Navbar />
            </header>
            <div className='layout__body'>
                <Outlet />
            </div>
            <div className='layout__footer'>
                <Footer />
            </div>
        </div>
    )
}

function Layout() {
    return (
        <BrowserRouter>
            <Routes>
                <Route element={<Layout4Route />}>
                    {/* Pages */}
                    <Route path='/Home' exact element={<Home />} />
                    <Route path="*" element={<Home />} />
                    <Route path="/Login" exact element={<Login />} />
                    <Route path="/Lesson" exact element={<LessonList />} />
                </Route>
            </Routes>
        </BrowserRouter>
    )
}


export default Layout