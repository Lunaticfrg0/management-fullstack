import { BaseButton } from "./button.styles";

const Button = ({children, buttonType, isLoading, ...otherProps}) => {
    return (
        <BaseButton disabled={isLoading} {...otherProps} >
            {children}
        </BaseButton>
    )
}

export default Button;