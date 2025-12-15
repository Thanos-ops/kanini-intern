import { useState } from 'react';
import './UserManagement.css';

interface UserData {
  name: string;
  email: string;
  phone: string;
  address: string;
  profileImage: File | null;
}

const UserManagement = () => {
  const [userData, setUserData] = useState<UserData>({
    name: '',
    email: '',
    phone: '',
    address: '',
    profileImage: null
  });

  const [preview, setPreview] = useState<string>('');

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setUserData(prev => ({ ...prev, [name]: value }));
  };

  const handleImageChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (file) {
      setUserData(prev => ({ ...prev, profileImage: file }));
      const reader = new FileReader();
      reader.onloadend = () => setPreview(reader.result as string);
      reader.readAsDataURL(file);
    }
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    console.log('User data:', userData);
    alert('User details uploaded successfully!');
  };

  return (
    <div className="user-management">
      <h2>Add User Details</h2>
      <p className="subtitle">Enter your information to get started</p>
      
      <form onSubmit={handleSubmit} className="user-form">
        <div className="form-group">
          <label htmlFor="name">Full Name</label>
          <input
            type="text"
            id="name"
            name="name"
            value={userData.name}
            onChange={handleInputChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="email">Email Address</label>
          <input
            type="email"
            id="email"
            name="email"
            value={userData.email}
            onChange={handleInputChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="phone">Phone Number</label>
          <input
            type="tel"
            id="phone"
            name="phone"
            value={userData.phone}
            onChange={handleInputChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="address">Delivery Address</label>
          <textarea
            id="address"
            name="address"
            value={userData.address}
            onChange={handleInputChange}
            rows={2}
            required
          />
        </div>

        <div className="image-upload">
          {preview ? (
            <img src={preview} alt="Profile" className="image-preview" />
          ) : (
            <div className="image-preview" style={{background: '#f0f0f5', display: 'flex', alignItems: 'center', justifyContent: 'center', fontSize: '24px', color: '#93959f'}}>📷</div>
          )}
          <button type="button" className="upload-btn" onClick={() => document.getElementById('profileImage')?.click()}>
            {preview ? 'Change Photo' : 'Add Photo'}
          </button>
          <input
            type="file"
            id="profileImage"
            className="hidden-input"
            accept="image/*"
            onChange={handleImageChange}
          />
        </div>

        <button type="submit" className="submit-btn">Continue</button>
      </form>
    </div>
  );
};

export default UserManagement;