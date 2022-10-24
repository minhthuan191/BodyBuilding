import React from 'react'

const Login = () => {
  return (
    <div className="layout__login">
      <div className='login__form'>
        <div className='login__content login__content--input '>
          <h2>Sign In</h2>
          <div className='login__content__inputBox'>
            <div>
              <input type="email" id="typeEmailX-2" />
              <label class="form-label" for="typeEmailX-2">Email</label>
            </div>
            <div>
              <input type="password" id="typePasswordX-2" />
              <label class="form-label" for="typePasswordX-2">Password</label>
            </div>
          </div>
          <div className='login__content__button'>
              <button className='login__content__button--login'>Login</button>
              <button className='login__content__button--signUp'>Sign me up</button>
          </div>
          <div className='login__content__button'>
              <button className='login__content__button--browsing'>Login with Google</button>
              <button className='login__content__button--browsing'>Login with FaceBook</button>
          </div>
        </div>
        <div className='login__content login__content--image'>
              <img src={require("../assets/Login.jpg")} alt=''/>
        </div>
      </div>
    </div>
  )
}

export default Login;