import React, { createContext, useContext, useState } from 'react';

import { Employee } from 'definitions/employee';

interface UserProps {
    children: JSX.Element;
}

interface UserData {
    user: Employee | undefined
    setUser: (user: Employee | undefined) => void;
    token: string | undefined
    setToken(token: string | undefined): void;
}

const UserContext = createContext({} as UserData);

const UserProvider: React.FC<UserProps> = ({ children }) => {
    const [user, setUser] = useState<Employee | undefined>();
    const [token, setToken] = useState<string | undefined>();

    return (
        <UserContext.Provider
            value={{
                user,
                token,
                setUser,
                setToken,
            }}>
            {children}
        </UserContext.Provider>
    );
};

const useMe = (): UserData => {
    const context = useContext(UserContext);

    return context;
};

export { UserProvider, useMe };