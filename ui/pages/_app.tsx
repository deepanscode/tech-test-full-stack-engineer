import {
    DehydratedState,
    Hydrate,
    QueryClient,
    QueryClientProvider,
} from '@tanstack/react-query'
import {ReactQueryDevtools} from '@tanstack/react-query-devtools'
import {AppProps} from "next/app";
import {useState} from "react";
import "globals.css"

export default function MyApp({Component, pageProps}: AppProps<{ dehydratedState: DehydratedState }>) {
    const [queryClient] = useState(() => new QueryClient())

    return (
        <QueryClientProvider client={queryClient}>
            <Hydrate state={pageProps.dehydratedState}>
                <Component {...pageProps} />
            </Hydrate>
            <ReactQueryDevtools/>
        </QueryClientProvider>
    )
}
