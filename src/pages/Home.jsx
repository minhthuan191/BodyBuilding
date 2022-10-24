import React from 'react'

const Home = () => {
    return (
        <>
            <div className='home__content home__content--poster'>
                <img src={require('../assets/Home__poster.jpg')} alt=''></img>
            </div>
            <div className='home__content home__content--opening'>
                <h1>Take your training to the next level</h1>
                <h2>Take your training to the next level with the ... app to help you get in the best shape of your life</h2>
                <div className='content__appget'>
                    <div className='content__appget__inside'>
                        <div className='appget__icon'>
                            <img src='' alt='' />
                        </div>
                        <div className='appget__content'>
                            <h4>Get US ON</h4>
                            <h3>Appstore</h3>
                        </div>
                    </div>
                    <div className='content__appget__inside'>
                        <div className='appget__icon'>
                            <img src='' alt='' />
                        </div>
                        <div className='appget__content'>
                            <h4>Get US ON</h4>
                            <h3>Google play</h3>
                        </div>
                    </div>
                </div>
            </div>
            <div className='home__content home__content--opening'>
                <h1>Take your training to the next level</h1>
                <h2>Take your training to the next level with the ... app to help you get in the best shape of your life</h2>
            </div>
        </>
    )
}

export default Home