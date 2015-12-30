#include <iostream>
#include <SDL.h>
#include <SDL_image.h>
#include <string>
#include <SDL_ttf.h>
#include <SDL_mixer.h>
#include <time.h>

#define PLAYER_SCORE_X 350
#define PLAYER_SCORE_Y 620

//Gloabal Variable for functions I use below main
int playerScore;
SDL_Rect makeBall;
SDL_Rect drawBall;
SDL_Rect backgroundDraw;
SDL_Rect backgroundOnScreen;
SDL_Rect player;
SDL_Rect playerPos;
SDL_Rect cpu;
SDL_Rect cpuPos;
SDL_Rect textRect;
int lives = 1, Yspeed = 3, Xspeed = 1;

//Function Prototypes
void CreateRect(SDL_Rect &rect, int xCoor, int yCoor, int width, int height);
SDL_Texture *LoadText(std::string filepath, SDL_Renderer *renderTarget);
void detectWallCollision(SDL_Rect &rect);
void detectObjCollison(SDL_Rect &b, SDL_Rect &pad);

int main(int argc, char *argv[]) {

    //Declaring every SINGLE variable
    SDL_Window *win = nullptr;
    SDL_Renderer *ren = nullptr;
    SDL_Texture *ball = nullptr;
    SDL_Texture *currentImg = nullptr;
    SDL_Texture *cpuPad = nullptr;
    SDL_Texture *background = nullptr;
    int textWid, textHeight;
    int cpuTextWid, cpuTextHeight;
    int ballTextWid, ballTextHeight;
    const int windowWid = 480, windowHeight = 640;


    if (SDL_Init(SDL_INIT_EVERYTHING) != 0)
        {
            std::cout << "SDL_Init Error: " << SDL_GetError() << std::endl;
            return 1;
        }

        SDL_Init(SDL_INIT_AUDIO);

    //Initializing TTF to write font on screen
    if (TTF_Init() < 0)
        {
            std::cout << "Error" << TTF_GetError() << std::endl;
            return 1;
        }
    //Initializing image types PNG and JPG
    int imgFlag = IMG_INIT_PNG|IMG_INIT_JPG;
        if(IMG_Init(imgFlag) != imgFlag)
            std::cout << "Error: Initializing other image format Failed" << IMG_GetError() << std::endl;

    //Creating Window
    win = SDL_CreateWindow("Ricochet", 100, 100, windowWid, windowHeight, SDL_WINDOW_SHOWN);
    if (win == nullptr){
        std::cout << "SDL_CreateWindow Error: " << SDL_GetError() << std::endl;
        SDL_Quit();
        return 1;
    }

    if(Mix_OpenAudio(44100, MIX_DEFAULT_FORMAT, 2, 2048) < 0)
    {
        std::cout << "Error: " << Mix_GetError() << std::endl;
        return 1;
    }

    //Loading Music tracks
    Mix_Music *startPlay = Mix_LoadMUS("start.mp3");
    Mix_Music *bgm = Mix_LoadMUS("guile.mp3");

    //creating to use GPU for drawing
    ren = SDL_CreateRenderer(win, -1, SDL_RENDERER_ACCELERATED | SDL_RENDERER_PRESENTVSYNC);
    if (ren == nullptr)
    {
        std::cout << "Error Creating Renderer" << std::endl;
        SDL_Quit();
        return 1;
    }

    //Loading images
    background = LoadText("space.jpg", ren);
    currentImg = LoadText("laser-blue.png", ren);
    cpuPad = LoadText("laser-red.png", ren);
    ball = LoadText("pokeball.png", ren);

    //Asking images for their attributes
    SDL_QueryTexture(currentImg, NULL, NULL, &textWid, &textHeight);
    SDL_QueryTexture(cpuPad, NULL, NULL, &cpuTextWid, &cpuTextHeight);
    SDL_QueryTexture(ball, NULL, NULL, &ballTextWid, &ballTextHeight);

    //Create Rects from Images given
    CreateRect(player, 0, 0, textWid, textHeight);
    CreateRect(cpu, 0, 0, cpuTextWid, cpuTextHeight);
    CreateRect(backgroundDraw, 0, 0, windowWid, windowHeight);
    CreateRect(makeBall, 0, 0, ballTextWid, ballTextHeight);

    //Create Rects to display on screen
    CreateRect(playerPos, 165, 560, textWid, textHeight);
    CreateRect(cpuPos, 165, 60, cpuTextWid, cpuTextHeight);
    CreateRect(backgroundOnScreen, 0, 0, windowWid, windowHeight);
    CreateRect(drawBall, 228, 308, ballTextWid, ballTextHeight);

    //Showing Text on screen
    TTF_Font *font = TTF_OpenFont("8_bit_Cool.ttf", 20);
    SDL_Color color = { 255, 255, 255, 255};
    SDL_Surface *textBox = TTF_RenderText_Solid(font, "Press Pokeball to Play!", color);
    SDL_Texture *text = SDL_CreateTextureFromSurface(ren, textBox);
    SDL_QueryTexture(text, NULL, NULL, &textRect.w, &textRect.h);
    CreateRect(textRect, 100, 200, textRect.w, textRect.h);

    //Creating bool for game
    bool isRunning = true;

    SDL_Event ev;

    while(isRunning)
    {
        if (drawBall.y + drawBall.h >= 640)
        {
            Yspeed = 0;
            lives--;
            Mix_Music *lost = Mix_LoadMUS("youlose.mp3");
            Mix_PlayMusic(lost, 1);
            Mix_FreeMusic(bgm);
            SDL_Delay(2000);
            isRunning = false;
        }


        SDL_RenderClear(ren);
        SDL_RenderCopy(ren, background, &backgroundDraw, &backgroundOnScreen);
        SDL_RenderCopy(ren, currentImg, &player, &playerPos);
        SDL_RenderCopy(ren, cpuPad, &cpu, &cpuPos);
        SDL_RenderCopy(ren, ball, &makeBall, &drawBall);
        SDL_RenderCopy(ren, text, NULL, &textRect);

        while(SDL_PollEvent(&ev) != 0)
        {
            cpuPos.x = cpuTextWid + ballTextWid / 2;

            if (ev.type == SDL_QUIT)
            {
                isRunning = false;
            }

            if (ev.type == SDL_MOUSEBUTTONUP)
            {
                if(ev.button.x >= 228 && ev.button.x <= 252 && ev.button.y >= 308 && ev.button.y <= 332 && drawBall.x == 228)
                {
                    Mix_PlayMusic(startPlay, 1);

                    SDL_Delay(4000);

                    SDL_FreeSurface(textBox);
                    SDL_DestroyTexture(text);

                    Mix_PlayMusic(bgm, -1);
                }
            }

            if (ev.type == SDL_MOUSEMOTION)
            {
                playerPos.x = (ev.motion.x - 75);
            }

        }

        if (Mix_PlayingMusic() == 1 )
        {
            drawBall.y += Yspeed;
            drawBall.x += Xspeed;
        }

        detectWallCollision(drawBall);

        cpuPos.x = drawBall.x - 63;

        if (drawBall.y + drawBall.h >= playerPos.y + 20 && drawBall.x > playerPos.x && drawBall.x < playerPos.x + playerPos.w)
        {
            Yspeed = -Yspeed *1.25;
        }
        else if (drawBall.y <= cpuPos.y + cpuPos.h - 20 && drawBall.x > cpuPos.x && drawBall.x < cpuPos.x + cpuPos.w)
        {
            Yspeed = -Yspeed * 1.25;
        }
        else
        {
            Yspeed = Yspeed;
        }

        SDL_RenderPresent(ren);
    }


    //Freeing all used memory to end program.
    //SDL_FreeSurface(textBox);
    SDL_DestroyTexture(background);
    SDL_DestroyTexture(currentImg);
    SDL_DestroyTexture(cpuPad);
    SDL_DestroyRenderer(ren);
    SDL_DestroyTexture(text);
    SDL_DestroyWindow(win);
    Mix_FreeMusic(startPlay);
    ren = nullptr;
    currentImg = nullptr;
    cpuPad = nullptr;
    textBox = nullptr;
    text = nullptr;
    win = nullptr;
    TTF_Quit();
    IMG_Quit();
    Mix_Quit();
    SDL_Quit();

    return 0;
}

//Turns images into textures for the renderer
SDL_Texture *LoadText(std::string filepath, SDL_Renderer *renderTarget)
{
    SDL_Texture *text = nullptr;
    SDL_Surface *surface = IMG_Load(filepath.c_str());

    if (surface == NULL)
        std::cout << "Error loading image!" << SDL_GetError() << std::endl;
    else
    {
        text = SDL_CreateTextureFromSurface(renderTarget, surface);
        if (text == NULL)
            std::cout << "Error creating texture!" << SDL_GetError() << std::endl;
    }

    SDL_FreeSurface(surface);

    return text;
}

//Function just creates rects
void CreateRect(SDL_Rect &rect, int xCoor, int yCoor, int width, int height)
{
    rect.x = xCoor;
    rect.y = yCoor;
    rect.w = width;
    rect.h = height;
}

void detectWallCollision(SDL_Rect &rect)
{
    if (rect.x + rect.w >= 480)
    {
        Xspeed = -Xspeed;
    }

    if (rect.x <= 0)
    {
        Xspeed = -Xspeed;
    }

    if (rect.y <= 0)
    {
        Yspeed = -Yspeed;
    }

}

void detectObjCollison(SDL_Rect &b, SDL_Rect &pad)
{
    if (b.y + b.h >= pad.y + 10)
    {
        Yspeed = -Yspeed * 1.9;
    }
}
